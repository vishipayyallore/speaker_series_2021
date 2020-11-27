import React from "react";

import { withAITracking } from '@microsoft/applicationinsights-react-js';
import reactPlugin from '../../services/app-insights.service';

function AboutPage() {
  return (
    <>
      <h2>About</h2>
      <p>This app uses React.</p>
    </>
  );
}

// export default AboutPage;
export default withAITracking(reactPlugin, AboutPage);
