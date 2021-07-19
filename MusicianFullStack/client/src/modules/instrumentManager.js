const apiUrl = '/api/instrument/';

export const getInstruments = () => {
  return fetch(apiUrl)
    .then(resp => resp.json());
};

export const searchInstruments = (criterion) => {
  return fetch(`${apiUrl}search?q=${criterion}`)
    .then(resp => resp.json());
};

export const getInstrument = (id) => {
  return fetch(apiUrl + id).then(resp => resp.json());
};

export const updateInstrument = (instrument) => {
  return fetch(apiUrl + instrument.id, {
    method: 'PUT',
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(instrument)
  });
};
