import API from './API';

const TaskGroupService = {
  get: async function (pageNumber = 1) {
    const resp = await API.get('taskGroups');
    const taskGroups = resp.data;
  },

  getById: async (taskGroupId) => {
    const resp = await API.get(`taskGroups/${taskGroupId}`);
    return resp.data;
  },

  getByProjectId: async (projectId) => {
    const resp = await API.get(`taskGroups/projectId/${projectId}`);
    return resp.data;
  },

  post: async (taskGroup) => {
    const resp = await API.post(`taskGroups`, taskGroup);
    return resp.data;
  },

  put: async (taskGroup) => {
    const resp = await API.put(`taskGroups/${taskGroup.id}`, taskGroup);
    return taskGroup;
  },

  delete: async (taskGroupId) => {
    await API.delete(`taskGroups/${taskGroupId}`);
    return taskGroupId;
  }
};

export default TaskGroupService;