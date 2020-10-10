import React, { createContext, useState } from 'react';

export const DifficultyContext = createContext();

export const DifficultyProvider = (props) => {
  const apiUrl = '/api/difficulty';
  const [difficulties, setDifficulties] = useState([]);

  const getDifficulties = () => {
    fetch(apiUrl)
      .then(resp => resp.json())
      .then(setDifficulties);
  };

  return (
    <DifficultyContext.Provider value={{ difficulties, getDifficulties }}>
      {props.children}
    </DifficultyContext.Provider>
  );
};