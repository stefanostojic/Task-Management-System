import React, { useState, useEffect } from 'react';
import City from '../City/City'

// STATEFUL FUNCTIONAL COMPONENT
function CitiesManager() {
    const [citiesState, setCitiesState] = useState([]);

    const loadCitiesHandler = async () => {
        console.log('Loading cities...');
        let res = await fetch('http://localhost:54720/api/userRoles');
        let roles = await res.json();
        roles.forEach(role => {
            console.log(`Role name: ${role.name}`);
        });
        setCitiesState(roles);
    };

    const saveCityHandler = async () => {
        console.log('Saving city...');

        let newCityName = document.getElementById('city-name').value;
        if (newCityName == null || newCityName.length === 0) {
            console.error('City name can\'t be empty.');
            return;
        }

        let city = {
            name: newCityName
        }

        console.log('City that will be saved: ', city);

        let res = await fetch(`http://localhost:54720/api/userRoles`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(city)
        });
        let confirmation = await res.json();
        if (res.ok) {
            console.log('The new user role was saved successfully.');
            setCitiesState([...citiesState, confirmation]);
        } else {
            console.warn(res);
        }
        console.log(confirmation);
        document.getElementById('role-name').value = "";
    };

    const [divVisibility, setDivVisibility] = useState(true);

    useEffect(() => {
        // async function fetchCities() {
        //     let res = await fetch('http://localhost:54720/api/userRoles');
        //     let roles = await res.json();
        //     setCitiesState(roles);
        // }
        loadCitiesHandler();
    }, [])

    const cityClickHandler = (cityName) => {
        console.log('Selected city: ', cityName);
    }

    const deleteHandler = (id) => {
        console.log('Deleting city: ', id);
    }

    const users = citiesState.map((data, id) => {
        return <City
            key={id}
            id={data.id}
            click={cityClickHandler}
            deleteClick={deleteHandler}
            name={data.name} />
    })

    return (
        <div className="manager cities-manager">
            <h1>Cities Manager</h1>
            <hr />
            <h4>Number of cities: {citiesState.length}</h4>
            {users}
            <hr />
            <button className="btn btn-primary" onClick={loadCitiesHandler}>Loads roles</button>
            <p>City name: </p>
            <input className="input input-sm" id="city-name" placeholder="New city name" />
            <button className="btn btn-sm btn-primary" onClick={saveCityHandler}>Save</button>
            <button onClick={() => setDivVisibility(!divVisibility)}>Change div visibility</button>

            {divVisibility ?
                <div>Visibile div!</div> :
                null
            }
        </div>
    );
}

export default CitiesManager;