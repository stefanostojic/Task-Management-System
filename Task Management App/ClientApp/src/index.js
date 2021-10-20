import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
// import { BrowserRouter } from 'react-router-dom';
import App from './App';
// import registerServiceWorker from './registerServiceWorker';
import Navigation from './components/Navigation';
import Home from './components/Home';
import Login from './components/Login';
import Projects from './components/Projects';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  // useLocation,
  // Link,
  // useRouteMatch,
  // useParams
} from "react-router-dom";
import Project from './components/Project';
import AddNewTaskGroup from './components/AddNewTaskGroup';
import AddNewTask from './components/AddNewTask';
import EditTaskGroup from './components/EditTaskGroup';
// import { TransitionGroup, CSSTransition } from 'react-transition-group';

// const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
// const rootElement = document.getElementById('root');

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <Navigation />
      {/* <TransitionGroup>
        <CSSTransition
          key={useLocation().key}
          classNames="fade"
          timeout={300}
        > */}
          {/* <Switch location={useLocation()}> */}
          <Switch >
            <Route exact path="/" component={Projects} />
            {/* <Route path="/projects/addNew" component={AddNewTaskGroup} /> */}
            <Route path="/projects/:projectId/taskGroups/:taskGroupId/edit" component={EditTaskGroup} />
            <Route path="/projects/:projectId/taskGroups/:taskGroupId/tasks/:taskId/:action" component={AddNewTask} /> 
            <Route path="/projects/:projectId/taskGroups/:taskGroupId/tasks/add" component={AddNewTask} /> 
            {/* <Route path="/projects/:projectId/taskGroups/:taskGroupId" component={AddNewTask} /> */}
            <Route path="/projects/:projectId" component={Project} />
            <Route path="/projects" component={Projects} />
            <Route path="/home" component={Home} />
            <Route path="/login" component={Login} />
          </Switch>
        {/* </CSSTransition>
      </TransitionGroup> */}
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);

// registerServiceWorker();

