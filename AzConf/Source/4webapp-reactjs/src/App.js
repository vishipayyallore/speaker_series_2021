import React from 'react';
import { Switch, Route } from 'react-router-dom';
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import TopNavbar from './components/layout/TopNavbar';
import Footer from './components/layout/Footer';
import SideNavbar from "./components/layout/SideNavBar";

import DashboardPage from "./components/pages/DashboardPage";
import AboutPage from "./components/pages/AboutPage";
import PageNotFound from "./components/shared/PageNotFound";
import AddProfessorPage from "./components/professors/AddProfessorPage";
import EditProfessorPage from "./components/professors/EditProfessorPage";
import DeleteProfessorPage from "./components/professors/DeleteProfessorPage";
import ListProfessorsPage from "./components/professors/ListProfessorsPage";

function App() {
  return (

    <>

      <TopNavbar title="College" />

      <div className="container-fluid">
        <ToastContainer autoClose={3000} hideProgressBar />
        <div className=" row">
          <div className="col-md-2 d-none d-md-block bg-sidebar sidebar">
            <div className="sidebar-sticky">
              <SideNavbar />
            </div>
          </div>
          <div className="col-md-10 ml-sm-auto col-lg-10 px-4">
            <Switch>
              <Route path="/dashboard" exact component={DashboardPage} />
              <Route path="/about" component={AboutPage} />
              <Route path="/professors" component={ListProfessorsPage} />
              <Route path="/add-professor" component={AddProfessorPage} />
              <Route path="/edit-professor/:professorId" component={EditProfessorPage} />
              <Route path="/delete-professor/:professorId" component={DeleteProfessorPage} />
              <Route path="/" exact component={DashboardPage} />
              <Route component={PageNotFound} />
            </Switch>
          </div>
        </div>
      </div>


      <Footer />
    </>
  );
}

export default App;

