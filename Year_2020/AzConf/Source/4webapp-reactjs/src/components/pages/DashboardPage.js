import React from "react";
import { Link } from "react-router-dom";

import { withAITracking } from '@microsoft/applicationinsights-react-js';
import reactPlugin from '../../services/app-insights.service';

function DashboardPage() {
    return (
        <>
            <h1 className="PageTitle">Application Dashboard</h1>
            <div className="row mb-4">
                <div className="col-sm-6">
                    <div className="card shadow text-black bg-light">
                        <div className="card-header">University</div>
                        <div className="card-body">
                            <h5 className="card-title">Professors</h5>
                            <p className="card-text">College Professors Module. View, Edit and Delete Professors. The backend is .Net Core 3.1 with EF Core and SQL Server. It also uses Redis Cache.</p>
                            <Link to="/professors" className="btn btn-maincolor shadow">Professors</Link>
                        </div>
                    </div>
                </div>
                <div className="col-sm-6">
                    <div className="card shadow text-black bg-light">
                        <div className="card-header">Library</div>
                        <div className="card-body">
                            <h5 className="card-title">Books</h5>
                            <p className="card-text">Library Books Module. Add, View, Edit and Delete Books. The backend is Node JS + Express. It using Mongo Db for data store</p>
                            <a href="/" className="btn btn-maincolor shadow">Coming Soon</a>
                        </div>
                    </div>
                </div>
            </div>

            <div className="row mb-4">
                <div className="col-sm-6">
                    <div className="card shadow text-black bg-light">
                        <div className="card-header">Trading</div>
                        <div className="card-body">
                            <h5 className="card-title">Stock Ticker</h5>
                            <p className="card-text">Retrieving the Stock Price. Add, View, Edit and Delete Books. The backend is Node JS + Express. It using Mongo Db for data store</p>
                            <a href="/" className="btn btn-maincolor shadow">Coming Soon</a>
                        </div>
                    </div>
                </div>
                <div className="col-sm-6">
                    <div className="card shadow text-black bg-light">
                        <div className="card-header">Students Enrollment</div>
                        <div className="card-body">
                            <h5 className="card-title">Students</h5>
                            <p className="card-text">Retrieving the Students. Add, View, Edit and Delete Books. The backend is Node JS + Express. It using Mongo Db for data store</p>
                            <a href="/" className="btn btn-maincolor shadow">Coming Soon</a>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

// export default DashboardPage;
export default withAITracking(reactPlugin, DashboardPage);