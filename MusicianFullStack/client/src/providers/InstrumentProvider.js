import React, { createContext, useState } from 'react';

export const InstrumentContext = createContext();

export const InstrumentProvider = (props) => {
  const apiUrl = '/api/instrument/';

  const [instruments, setInstruments] = useState([]);

  const getInstruments = () => {
    fetch(apiUrl)
      .then(resp => resp.json())
      .then(setInstruments);
  };

  const getInstrument = (id) => {
    return fetch(apiUrl + id).then(resp => resp.json());
  }

  const updateInstrument = (instrument) => {
    return fetch(apiUrl + instrument.id, {
      method: 'PUT',
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(instrument)
    });
  }

  return (
    <InstrumentContext.Provider value={{ instruments, getInstruments, getInstrument, updateInstrument }}>
      {props.children}
    </InstrumentContext.Provider>
  )
};