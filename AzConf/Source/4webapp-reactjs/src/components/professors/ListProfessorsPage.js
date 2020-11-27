import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import ClockLoader from "react-spinners/ClockLoader";

import { withAITracking } from '@microsoft/applicationinsights-react-js';
import reactPlugin from '../../services/app-insights.service';

import { getAllProfessors } from "../../services/professorsService";

function ListProfessorsPage() {

  const [professors, setProfessors] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (professors.length === 0) {
      getAllProfessors()
        .then(_professors => {
          setProfessors(_professors);
          setLoading(false);
        });
    }
  }, [professors.length]);

  return (
    <div>
      <div className="card shadow mt-2 mb-2">
        <div className="card-header">
          <h2 className="PageTitle">Professors List</h2>
        </div>
        <div className="card-body">
          <div>
            <Link to={"/add-professor"} className="float">
              <i className="fa fa-plus float-margintop"></i>
            </Link>
          </div>
          <div className="sweet-loading d-flex justify-content-center">
            <ClockLoader
              size={150}
              color={"#123abc"}
              loading={loading}
            />
          </div>
          <br></br>
          <table className='table table-striped table-bordered shadow' hidden={loading} aria-labelledby="tableLabel">
            <thead className="table-header-dark">
              <tr>
                <th>Professor Id</th>
                <th>Name</th>
                <th>DOJ</th>
                <th>Teaches</th>
                <th>Salary</th>
                <th>Is Phd</th>
                <th scope="col">Actions</th>
              </tr>
            </thead>
            <tbody>
              {
                professors.map(professor => {
                  return (
                    <tr key={professor.professorId}>
                      <td>{professor.professorId}</td>
                      <td>{professor.name}</td>
                      <td>{dateFormat(professor.doj, "mmm dd, yyyy")}</td>
                      <td>{professor.teaches}</td>
                      <td>{professor.salary}</td>
                      <td>{professor.isPhd.toString()}</td>
                      <th scope="col">
                        <Link to={"/edit-professor/" + professor.professorId} className="btn btn-warning btn-sm ml-2 shadow mr-2">
                          <i className="fa fa-edit fa-fw" aria-hidden="true"></i> Edit</Link>
                        <Link to={"/delete-professor/" + professor.professorId} className="btn btn-danger btn-sm ml-2 shadow">
                          <i className="fa fa-trash" aria-hidden="true"></i> Delete</Link>
                      </th>
                    </tr>
                  );
                })
              }
            </tbody>
          </table>
        </div>
      </div>
    </div >
  );
}

// export default ListProfessorsPage;
export default withAITracking(reactPlugin, ListProfessorsPage);