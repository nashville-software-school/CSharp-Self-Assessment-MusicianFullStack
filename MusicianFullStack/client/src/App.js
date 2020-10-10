import React from 'react';
import './App.css';
import { BrowserRouter as Router } from "react-router-dom";
import { InstrumentProvider } from './providers/InstrumentProvider';
import ApplicationViews from './ApplicationViews';
import { DifficultyProvider } from './providers/DifficultyProvider';

function App() {
  return (
    <Router>
      <DifficultyProvider>
        <InstrumentProvider>
          <div className="App">
            <ApplicationViews />
          </div>
        </InstrumentProvider>
      </DifficultyProvider>
    </Router>
  );
}

export default App;
