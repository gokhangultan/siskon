// @material-ui/icons
import Dashboard from "@material-ui/icons/Dashboard";
import Person from "@material-ui/icons/Person";
// core components/views for Admin layout
import DashboardPage from "views/Dashboard/Dashboard.js";
import BrandPage from "views/VehicleBrand/BrandMain.js";
import ModelPage from "views/VehicleModel/ModelMain.js";
import VehiclePage from "views/Vehicle/VehicleMain.js";

const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "Dashboard",
    icon: Dashboard,
    component: DashboardPage,
    layout: "/admin",
  },
  {
    path: "/brand",
    name: "Brand Management",
    icon: Person,
    component: BrandPage,
    layout: "/admin",
  },
  {
    path: "/model",
    name: "Model Management",
    icon: Person,
    component: ModelPage,
    layout: "/admin",
  },
  {
    path: "/vehicle",
    name: "Vehicle Management",
    icon: Person,
    component: VehiclePage,
    layout: "/admin",
  },
];

export default dashboardRoutes;
