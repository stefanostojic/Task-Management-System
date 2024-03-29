import React from 'react';
import UserAvatar from './UserAvatar';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import ProjectService from '../services/ProjectService';
import { useState, useEffect } from 'react';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
    },
}));

const Navigation = () => {
    const [, setProjects] = useState([]);

    useEffect(() => {
        async function fetchProjects() {
            const projectsData = await ProjectService.get();
            console.log({ projectsData });
            setProjects(projectsData);
        }
        fetchProjects();
    }, []);

    const classes = useStyles();


    return (

        <AppBar position="static">
            <Toolbar>
                <IconButton edge="start" className={classes.menuButton} color="inherit" aria-label="menu">
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" className={classes.title}>
                    Task Management System
                </Typography>
                <UserAvatar />
                <Button color="inherit">Logout</Button>
            </Toolbar>
        </AppBar>
    );
};

export default Navigation;