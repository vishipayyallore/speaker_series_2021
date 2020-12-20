import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { toast } from "react-toastify";

import { withAITracking } from '@microsoft/applicationinsights-react-js';
import reactPlugin from '../../services/app-insights.service';

import { saveProfessor } from "../../services/professorsService";

function AddProfessorPage() {

  let history = useHistory();

  const [professor, setProfessor] = useState({
    name: "",
    doj: (new Date()).toISOString().slice(0, 10).replace(/-/g, "-").replace("T", " "),
    teaches: "C#",
    salary: 0.0,
    isPhd: false
  });

  function handleSaveProfessorSubmit(event) {

    event.preventDefault();
    saveProfessor(professor)
      .then(_ => {
        history.push('/professors');
        toast.success("Professor Added.");
      })
      .catch(_ => {
        toast.error("Error adding Professor");
      });
  }

  function handleFormChange({ target }) {

    const value = (target.type === 'checkbox') ? target.checked : (target.type === 'number') ? +target.value : target.value;

    setProfessor({
      ...professor,
      [target.name]: value
    });
  }

  return (

    <div className="card shadow mt-2 mb-2">
      <div className="card-header">
        <h2 className="PageTitle">Add Professor</h2>
      </div>
      <div className="card-body">
        <div className="col-md-8 mb-4 shadow px-2 py-2">
          <form>

            <div className="form-group divflex labelAndTextbox">
              <label className="element col-md-2">Name : </label>
              <input type="text" name="name" className="form-control element ml-4" maxLength="100"
                onChange={handleFormChange} value={professor.name} />
            </div>

            <div className="form-group divflex labelAndTextbox">
              <label className="element col-md-2">DOJ: </label>
              <input type="date" name="doj" className="form-control element ml-4"
                onChange={handleFormChange} value={new Date(professor.doj).toISOString().slice(0, 10).replace(/-/g, "-").replace("T", " ")} />
            </div>

            <div className="form-group divflex labelAndTextbox">
              <label className="element col-md-2">Teaches : </label>
              <input type="text" name="teaches" className="form-control element ml-4" maxLength="100"
                onChange={handleFormChange} value={professor.teaches} />
            </div>

            <div className="form-group divflex labelAndTextbox">
              <label className="element col-md-2">Salary : </label>
              <input type="number" name="salary" className="form-control element ml-4" maxLength="18"
                onChange={handleFormChange} value={professor.salary} />
            </div>

            <div className="form-group divflex labelAndTextbox">
              <label className="element col-md-2">Is Phd: </label>
              <div className="col-sm-1">
                <input type="checkbox" name="isPhd" onChange={handleFormChange} className="form-control element ml-2" checked={professor.isPhd} />
              </div>
            </div>

          </form>

          <Link to="" onClick={handleSaveProfessorSubmit} type="submit" className="btn btn-primary btn-sm ml-2 shadow mr-2">
            <i className="fa fa-save fa-fw" aria-hidden="true"></i> Save</Link>
          <Link to="/professors" className="btn btn-maincolor btn-sm ml-2 shadow">
            <i className="fa fa-list" aria-hidden="true"></i> List</Link>

        </div>
      </div>
    </div>
  );
}

// export default AddProfessorPage;
export default withAITracking(reactPlugin, AddProfessorPage);
