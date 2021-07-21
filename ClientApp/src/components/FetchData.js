import React from 'react';

const FetchData = () => {
  let [dinosaurs, populateDinosaurs] = React.useState([]);

  function onSubmit(event) {
    event.preventDefault()
    const data = {
      name: event.target.name.value,
      species: event.target.species.value,
      age: event.target.age.value,
      gender: event.target.gender.value
    }
    console.log(data)
    fetch(`http://localhost:5000/api/Animals`, 
    {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data),
    })
    .then(response => response.json())
    .then(response => console.log(response))
    .catch(error => console.log(error))
  }

  const fetchApi = React.useCallback(() => {
    fetch(`http://localhost:5000/api/Animals`, 
    {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      },
    })
    .then(response => response.json())
    .then(response => populateDinosaurs(response))
    .catch(error => console.log(error))
  }, [])

  React.useEffect(() => {
    fetchApi()
  }, [fetchApi])

  return (
    <div>
      <h1 id="tabelLabel" >Weather forecast</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {Object.values(dinosaurs).map(dino => {
        return <ul>
          <li>Dino name: {dino.name} :: Species: {dino.species} :: Age {dino.age} :: Gender: {dino.gender}</li>
        </ul>
      })}
      <button type='button' onClick={fetchApi}>Fetch data again</button>
      <hr />
      <h3>Add a new dinosaur</h3>
      <form onSubmit={onSubmit}>
        <label htmlFor='name'>Enter a name:
          <input type='text' name='name' defaultValue='Michael' placeholder='Michael' />
        </label>
        <br />
        <label htmlFor='species'>Species:
          <input type='text' name='species' defaultValue='Dinosaurus epithelius' placeholder='Dinosaurus epithelius' />
        </label>
        <br />
        <label htmlFor='age'>Age:
          <input type='number' name='age' step='1' min='0' defaultValue='21' placeholder='21' />
        </label>
        <br />
        <label htmlFor='gender'>Gender:
          <select name='gender'>
            <option value='Non-binary'>Non-binary</option>
            <option value='Female'>Female</option>
            <option value='Male'>Male</option>
          </select>
        </label>
        <br />
        <button type='submit'>Add a dino</button>
      </form>
    </div>
  );
}

export default FetchData
