import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardMedia from '@material-ui/core/CardMedia';
import {
  // BrowserRouter as Router,
  // Switch,
  // Route,
  Link,
  // useRouteMatch,
  // useParams
} from "react-router-dom";

const useStyles = makeStyles({
  root: {
    width: 275,
    height: 180,
    margin: 10,
    boxShadow: '2px 3px 7px 2px lightgrey',
    position: 'relative'
  },
  bullet: {
    display: 'inline-block',
    margin: '0 2px',
    transform: 'scale(0.8)',
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },
  title: {
    height: '1.5em',
    overflow: 'hidden',
    wordBreak: 'break-all',
  },
  description: {
    height: '5.26em',
    overflow: 'hidden',
    wordBreak: 'break-all',
  },
  buttons: {
    position: 'absolute',
    bottom: 0,
    right: 0
  }
});

export default function ProjectCard({ project }) {
  const classes = useStyles();
  const bull = <span className={classes.bullet}>•</span>;
  return (
    <Card className={classes.root}>
      <CardActionArea>
        <CardMedia
          className={classes.media}
          image="/static/images/cards/contemplative-reptile.jpg"
          title="Contemplative Reptile"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2" className={classes.title}>
            {project.name}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p" className={classes.description}>
            {project.description}
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions className={classes.buttons}>
        <Button size="small" color="primary">
          <Link to={`/projects/${project.id}`}>Details</Link>
        </Button>
      </CardActions>
    </Card>
  );
}