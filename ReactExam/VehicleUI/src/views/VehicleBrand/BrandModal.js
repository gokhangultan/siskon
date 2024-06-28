import React, { useState } from "react";
import PropTypes from "prop-types";
//import { makeStyles } from "@material-ui/core/styles";

// core components
import Modal from "react-bootstrap/Modal";
import Dialog from "@material-ui/core/Dialog";
import DialogTitle from "@material-ui/core/DialogTitle";
import DialogContent from "@material-ui/core/DialogContent";
import DialogActions from "@material-ui/core/DialogActions";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";

const BrandModal = (props) => {
  const [data, setData] = useState(props.detail);

  const inputChange = (name, value) => {
    setData({ ...data, [name]: value });
  };

  return (
    <Dialog
      open={true}
      keepMounted
      onClose={() => props.handleClose()}
      aria-labelledby="classic-modal-slide-title"
      aria-describedby="classic-modal-slide-description"
    >
      <DialogTitle closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Brand - {props.detail.BrandId ? "Update" : "Create"}
        </Modal.Title>
      </DialogTitle>
      <DialogContent>
        <Form style={{ width: "300px" }}>
          <Form.Group controlId="BrandName">
            <Form.Label>Brand Name</Form.Label>
            <Form.Control
              type="text"
              value={data.BrandName}
              onChange={(e) => inputChange("BrandName", e.target.value)}
              placeholder="Brand Name"
            />
          </Form.Group>
          <Form.Group controlId="Active">
            <Form.Check
              type="checkbox"
              checked={data.Active}
              onChange={(e) => inputChange("Active", e.target.checked)}
              label="Active"
            />
          </Form.Group>
        </Form>
      </DialogContent>
      <DialogActions>
        <Button
          onClick={props.handleClose}
          variant="contained"
          color="secondary"
        >
          Close
        </Button>
        <Button color="primary" onClick={() => props.addOrUpdateBrand(data)}>
          Save
        </Button>
      </DialogActions>
    </Dialog>
  );
};
BrandModal.propTypes = {
  open: PropTypes.bool.isRequired,
  handleClose: PropTypes.func.isRequired,
  addOrUpdateBrand: PropTypes.func,
  detail: PropTypes.object.isRequired,
};
export default BrandModal;
