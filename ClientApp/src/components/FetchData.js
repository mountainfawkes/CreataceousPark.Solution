import React from 'react';

const FetchData = () => {
  let [forecastData, populateForecastData] = React.useState([]);

  const fetchApi = React.useCallback(() => {
    fetch(`http://localhost:5000/api/Animals`, 
    {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    .then(response => response.json())
    .then(response => populateForecastData(response))
    .catch(error => console.log(error))
  }, [])

  React.useEffect(() => {
    fetchApi()
  }, [fetchApi])

  return (
    <div>
      <h1 id="tabelLabel" >Weather forecast</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {Object.values(forecastData).map(dino => {
        return <ul>
          <li>Dino name: {dino.name} :: Species: {dino.species} :: Age {dino.age} :: Gender: {dino.gender}</li>
        </ul>
      })}
      <button type='button' onClick={fetchApi}>Fetch data again</button>
    </div>
  );
}

export default FetchData
