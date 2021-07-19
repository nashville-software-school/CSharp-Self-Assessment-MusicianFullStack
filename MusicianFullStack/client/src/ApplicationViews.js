import React from 'react';
import { Switch, Route } from "react-router-dom";
import InstrumentList from './components/InstrumentList';
import InstrumentSearch from './components/InstrumentSearch';
import InstrumentForm from './components/InstrumentForm';

const ApplicationViews = () => {
  return (
    <Switch>
      <Route path='/' exact>
        <InstrumentList />
      </Route>

      <Route path='/search'>
        <InstrumentSearch />
      </Route>

      <Route path='/edit/:id'>
        <InstrumentForm/>
      </Route>
    </Switch>
  );
};

export default ApplicationViews;