import React, { useState, useEffect } from "react";
import { makeStyles } from "@material-ui/core/styles";
import {
  Grid,
  Paper,
  Typography,
  TextField,
  Button,
  FormControlLabel,
  Checkbox,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from "@material-ui/core";
import axios from "axios";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    padding: theme.spacing(2),
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: "center",
    color: theme.palette.text.secondary,
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 200,
  },
  submitButton: {
    marginTop: theme.spacing(2),
    marginRight: theme.spacing(2),
  },
}));

const VehicleForm = () => {
  const classes = useStyles();
  const [formData, setFormData] = useState({
    nickname: "",
    modelID: "",
    isActive: false,
    modelYear: "",
  });
  const [loading, setLoading] = useState(false);
  const [open, setOpen] = useState(false);
  const [vehicles, setVehicles] = useState([]);
  const [brandNames, setBrandNames] = useState([]);

  useEffect(() => {
    fetchBrandNames();
    fetchVehicles();
  }, []);

  const fetchBrandNames = async () => {
    try {
      const response = await axios.get("https://localhost:5001/api/Brand/lov");
      const brands = response.data.map((brand) => ({
        brandID: brand.BrandId,
        brandName: brand.BrandName,
      }));
      console.log("Brand names:", brands);
      setBrandNames(brands);
    } catch (error) {
      console.error("Error while fetching brand names:", error);
    }
  };

  const fetchVehicles = async () => {
    try {
      const response = await axios.get("/api/vehicle");
      setVehicles(response.data);
    } catch (error) {
      console.error("Error while fetching vehicles:", error);
      
    }
  };

  const handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.post("/api/vehicle", formData);
      console.log("Post request response:", response.data);
      fetchVehicles();
      handleClose();
    } catch (error) {
      console.error("Error while submitting:", error);
     
    }
  };

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleApplyFilters = async () => {
    try {
      const response = await axios.get(`/api/vehicle/${formData.modelYear}`);
      setVehicles(response.data);
    } catch (error) {
      console.error("Error while applying filters:", error);
      
    }
  };

  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography variant="h5">Vehicle Registration Form</Typography>
          </Paper>
        </Grid>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Button
              variant="contained"
              color="primary"
              onClick={handleOpen}
              className={classes.submitButton}
            >
              Add New Vehicle
            </Button>
            <Button
              variant="contained"
              color="primary"
              onClick={fetchVehicles}
              className={classes.submitButton}
            >
              List Vehicles
            </Button>
            <Dialog open={open} onClose={handleClose}>
              <DialogTitle>Add New Vehicle</DialogTitle>
              <DialogContent>
                <form onSubmit={handleSubmit}>
                  <TextField
                    label="Nickname of Vehicle"
                    name="nickname"
                    value={formData.nickname}
                    onChange={handleChange}
                    required
                    fullWidth
                    variant="outlined"
                    margin="normal"
                  />

                  <TextField
                    label="Model ID"
                    name="modelID"
                    value={formData.modelID}
                    onChange={handleChange}
                    required
                    fullWidth
                    variant="outlined"
                    margin="normal"
                  />

                  <FormControlLabel
                    control={
                      <Checkbox
                        checked={formData.isActive}
                        onChange={handleChange}
                        name="isActive"
                        color="primary"
                      />
                    }
                    label="Is Active"
                  />

                  <DialogActions>
                    <Button onClick={handleClose} color="secondary">
                      Cancel
                    </Button>
                    <Button
                      type="submit"
                      variant="contained"
                      color="primary"
                      className={classes.submitButton}
                    >
                      Submit
                    </Button>
                  </DialogActions>
                </form>
              </DialogContent>
            </Dialog>
          </Paper>
        </Grid>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography variant="h5">Vehicle List</Typography>
            <ul>
              {vehicles.map((vehicle) => (
                <li key={vehicle.vehicleID}>
                  {vehicle.nickname} - {vehicle.modelID} - {vehicle.isActive ? "Active" : "Inactive"}
                </li>
              ))}
            </ul>
          </Paper>
        </Grid>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography variant="h5">Filter Vehicles</Typography>
            <form onSubmit={(e) => { e.preventDefault(); handleApplyFilters(); }}>
              <FormControl
                className={classes.formControl}
                fullWidth
                variant="outlined"
                margin="normal"
              >
                <InputLabel id="brandNameFilterLabel">Brand Name</InputLabel>
                <Select
                  labelId="brandNameFilterLabel"
                  id="brandNameFilter"
                  name="brandName"
                  value={formData.brandName}
                  onChange={handleChange}
                  label="Brand Name"
                >
                  {brandNames.map((brand) => (
                    <MenuItem key={brand.brandID} value={brand.brandName}>
                      {brand.brandName}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>

              <TextField
                label="Model Year"
                name="modelYear"
                value={formData.modelYear}
                onChange={handleChange}
                fullWidth
                variant="outlined"
                margin="normal"
              />

              <Button
                type="submit"
                variant="contained"
                color="primary"
                className={classes.submitButton}
              >
                Apply Filters
              </Button>
            </form>
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
};

export default VehicleForm;
