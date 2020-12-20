import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";

import React from "react";
import { render } from "react-dom";
import App from "./App";
import { BrowserRouter as Router } from "react-router-dom";

render(
  <Router>
    <App />
  </Router>,
  document.getElementById("root")
);
