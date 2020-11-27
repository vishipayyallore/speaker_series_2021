import React from "react";
import { Link } from "react-router-dom";

import pageNotFoundImage from "./404PageNotFound.png";

function PageNotFound() {
    return (
        <div>
            <div className="container mt-2">
                <p>
                    <Link to="/" className="btn btn-maincolor shadow">Back to Home</Link>
                </p>
                <hr />
                <img src={pageNotFoundImage} alt="Page Not Found" />
                <hr />
            </div>
        </div>
    );
}

export default PageNotFound;
