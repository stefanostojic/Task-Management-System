import React from 'react';

//STATELESS FUNCTIONAL COMPONENT
const City = (props) => {
    return (
        <div onClick={() => props.click(props.name)} className="item city">
            <div className="text">
                {props.name}
            </div>
            <div onClick={() => props.deleteClick(props.id)} className="button">
                X
            </div>

        </div>
    );
}

export default City;