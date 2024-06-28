import React, { useEffect, useState } from "react";

import axios from "axios";

// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Table from "components/Table/DataTable.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import Button from "@material-ui/core/Button";

// Config
import config from "../../config.js";

// Modal
import BrandModal from "./BrandModal.js";

// Style
import "./Brand.css";

const BrandMain = () => {
  const [brandData, setBrandData] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [editedBrand, setEditedBrand] = useState(undefined);
  const [removeSelected, setRemoveSelected] = useState(false);

  //#region Actions
  const getBrandListAction = () => {
    axios({
      method: "post",
      url: `${config.DefaultApiUrl}/brand/all`,
      data: {},
      transformResponse: [
        (data) => {
          setBrandData(JSON.parse(data));
          setRemoveSelected(false);
        },
      ],
    });
  };

  const addOrUpdateBrandActions = (data) => {
    const method = data.BrandId ? "put" : "post";
    axios({
      method: method,
      url: `${config.DefaultApiUrl}/brand`,
      data: data,
      transformResponse: [
        () => {
          setShowModal(false);
          alert("Kayıt işlemi tamamlanmıştır");
          getBrandListAction();
        },
      ],
    });
  };

  const deleteBrandActions = (data) => {
    console.log(data);
    axios({
      method: "delete",
      url: `${config.DefaultApiUrl}/brand/${data[0]}`,
      transformResponse: [
        () => {
          alert("Silme işlemi tamamlanmıştır");
          setRemoveSelected(true);
          getBrandListAction();
        },
      ],
    });
  };

  //#endregion

  useEffect(() => {
    getBrandListAction();
  }, []);

  const newBrand = () => {
    setEditedBrand({
      Active: true,
      BrandName: "",
      BrandId: undefined,
    });
    setShowModal(true);
  };

  const cells = [
    {
      id: "BrandName",
      numeric: false,
      disablePadding: true,
      label: "Brand Name",
      dataType: "text",
    },
    {
      id: "Active",
      numeric: false,
      disablePadding: false,
      label: "Is Active",
      dataType: "boolean",
    },
  ];
  return (
    <GridContainer>
      <GridItem xs={12} sm={12} md={12}>
        <Card>
          <CardHeader color="info">
            <p>
              Click to add a <Button onClick={newBrand}>New Brand</Button>
            </p>
          </CardHeader>
          <CardBody>
            {brandData && (
              <Table
                headCells={cells}
                data={brandData}
                primaryId="BrandId"
                handleEdit={(rowData) => {
                  setEditedBrand(rowData);
                  setShowModal(true);
                }}
                handleDelete={(rows) => {
                  deleteBrandActions(rows);
                }}
                removeSelected={removeSelected}
              />
            )}
          </CardBody>
        </Card>
      </GridItem>
      {showModal && (
        <BrandModal
          open={showModal}
          detail={editedBrand}
          handleClose={() => setShowModal(false)}
          addOrUpdateBrand={(data) => addOrUpdateBrandActions(data)}
        />
      )}
    </GridContainer>
  );
};

export default BrandMain;
