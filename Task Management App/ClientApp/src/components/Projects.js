import React from 'react';
import { useState, useEffect } from 'react'

import ProjectService from '../services/ProjectService';
import AddNewProject from './AddNewProject';
import ProjectCard from './ProjectCard';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Pagination from '@material-ui/lab/Pagination';

import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  root: {
    marginTop: 36,
    flexGrow: 1
  },
  paper: {
    height: 140,
    width: 100,
  },
  control: {
    padding: theme.spacing(2),
  },
}));

/**
 * Displays all users projects grouped in two categories: 
 * - users own projects 
 * - project the user is working on
 * 
 * Contains: 'AddNewProject' and 'ProjectCard'
 */
const Projects = () => {
  const classes = useStyles();
  const [spacing, setSpacing] = React.useState(5);
  const [projects, setProjects] = useState();
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [pageSize, setPageSize] = useState(3);

  useEffect(() => {
    loadProjects(1);
  }, []);

  const loadProjects = (pageNumber = 1) => {
    ProjectService.get({ pageNumber: pageNumber, pageSize: 3 })
      .then(data => {
        setProjects(data.items);
        setCurrentPage(data.currentPage);
        setPageSize(data.pageSize);
        setTotalPages(data.totalPages);
      });
  };

  const changePage = (pageNumber) => {
    loadProjects(pageNumber);
  };

  return (
    <Container>

      <div className='container'>
        <div className='row'>
          <div className='col-12'>
            <div className='row'>
              <div className='col-3'>
                <AddNewProject saveSuccessful={() => loadProjects(currentPage)}></AddNewProject>
              </div>
              {projects && projects.map(project => (
                <div className='col-3' key={project.id}><ProjectCard project={project} /></div>
              ))}
            </div>
            <div className='row'>
              
              <div className="col-12 mt-3 d-flex justify-content-center">
                <Pagination count={totalPages - 1} page={currentPage} onChange={(event, page) => changePage(page)} variant="outlined" color="primary" />
              </div>
            </div>
          </div>
        </div>
      </div>

    </Container>
  );
}

export default Projects;