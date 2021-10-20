import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardMedia from '@material-ui/core/CardMedia';
import Avatar from '@material-ui/core/Avatar';
import AvatarGroup from '@material-ui/lab/AvatarGroup';
import {
  // BrowserRouter as Router,
  // Switch,
  // Route,
  Link,
  // useRouteMatch,
  useParams
} from "react-router-dom";

const useStyles = makeStyles({
  root: {
    // minWidth: 275,
    // maxWidth: 300,
    marginTop: 16,
    boxShadow: '2px 3px 7px 2px lightgrey'
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
  description: {
    fontSize: 14,
    color: 'darkgray',
    margin: 0
  },
});

export default function TaskCard({ task }) {
  let { projectId } = useParams();
  const classes = useStyles();
  const bull = <span className={classes.bullet}>•</span>;

  const leftBorderStyling = () => {
    const date = Date.now();

    if (Date.parse(task.dueDate) > date) {
      return { borderLeft: '4px solid white' };
    }

    return { borderLeft: '4px solid red' }
  };

  return (
    <Card className={classes.root} style={leftBorderStyling()}>
      <CardActionArea>
        <CardMedia
          className={classes.media}
          image="/static/images/cards/contemplative-reptile.jpg"
          title="Contemplative Reptile"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            {task.name}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p">
            {task.description}
          </Typography>
        </CardContent>
      </CardActionArea>
      <div className='d-flex justify-content-between p-3'>
        {/* <Button size="small" color="primary">
          Share
        </Button> */}
        {task.assignees.length > 0 &&
          <AvatarGroup max={3}>
            {task.assignees.map(assignee => (
              <Avatar key={assignee.id}>{assignee.firstName.charAt(0).toUpperCase()}</Avatar>
            ))}
          </AvatarGroup>}
        {task.assignees.length === 0 && (
          <p className={classes.description}>No assignees yet.</p>
        )}
        <Link to={`/projects/${projectId}/taskGroups/${task.taskGroupID}/tasks/${task.id}/edit`}>
          <Button size="small" color="primary" className='float-right'>
            Details
          </Button>
        </Link>
      </div>
    </Card>
  );
}