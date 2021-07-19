import React from 'react';
import './App.css';
import { BrowserRouter as Router, Link } from "react-router-dom";
import ApplicationViews from './ApplicationViews';

function App() {
  return (
    <Router>
      <div className="App">
        <header>
          <Link to="/">Home</Link>
          <Link to="/search">Search</Link>
        </header>
        <main>
          <ApplicationViews />
        </main>
      </div>
    </Router>
  );
}

export default App;
