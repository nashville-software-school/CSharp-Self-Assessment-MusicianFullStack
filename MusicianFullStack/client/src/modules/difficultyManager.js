const apiUrl = '/api/difficulty';

export const getDifficulties = () => {
  return fetch(apiUrl).then(resp => resp.json())
};
