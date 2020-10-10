import React, { createContext, useState } from 'react';

export const InstrumentContext = createContext();

export const InstrumentProvider = (props) => {
  const apiUrl = 'api/instrument/';

  const [instruments, setInstruments] = useState([]);

  const getInstruments = () => {
    fetch(apiUrl)
      .then(resp => resp.json())
      .then(setInstruments);
  };

  return (
    <InstrumentContext.Provider value={{ instruments, getInstruments }}>
      {props.children}
    </InstrumentContext.Provider>
  )
};