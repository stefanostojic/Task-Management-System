import React from 'react';
import { useState } from 'react'
import ProjectService from '../services/ProjectService';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
  root: {
    minWidth: 275,
    maxWidth: 275,
    padding: 16,
    margin: 10,
    oveflowX: 'scroll',
    // boxShadow: '2px 3px 7px 2px lightgrey',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  },
  plusContainer: {
    width: '150px',
    height: '150px',
    fontSize: 100,
    backgroundColor: '#688df6',
    borderRadius: '100px',
    color: 'white',
    cursor: 'pointer'
  }
});

const AddNewProject = ({ saveSuccessful }) => {
  const classes = useStyles();
  const [formVisibility, setFormVisibility] = useState(false);
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');

  const save = () => {
    ProjectService.post({
      name,
      description,
      userID: 'C68AF42E-FD7C-4EBB-A8D1-F714A47F60A7'
    }).then(newProject => {
      console.info('New project added', newProject);
      saveSuccessful()
    });
    cancel();
  };
  const cancel = () => {
    setName('');
    setDescription('');

    setFormVisibility(false);
  };

  return (
    <div className={classes.root}>

      {!formVisibility &&
        <div className={classes.plusContainer} onClick={() => setFormVisibility(true)}>
          <div className='text-center' style={{ lineHeight: '1.3em' }}>
            +
          </div>
        </div>
      }

      {formVisibility && (
        <div className="form-group mb-0">
          <label>New project</label>
          <input type="text" className="form-control" placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} />
          {/* <small className="form-text text-muted mb-3">The project name must be between 1 and 15 letters long.</small> */}
          <input type="text" className="form-control my-1" placeholder="Description" value={description} onChange={(e) => setDescription(e.target.value)} />
          {/* <small className="form-text text-muted mb-3">The projects description must be between 1 and 255 letters long.</small> */}
          <button className='btn btn-danger float-left' onClick={() => cancel()}>Cancel</button>
          <button className='btn btn-primary float-right' onClick={() => save()}>Add</button>
        </div>
      )}
    </div>
  );
}

export default AddNewProject;