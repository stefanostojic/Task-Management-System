import API from './API';

const TaskService = {
  get: async function ({ taskGroupId, pageNumber = 1, pageSize = 3 }) {
    console.log({ taskGroupId, pageNumber, pageSize });
    const resp = await API.get('tasks', { params: { taskGroupId, pageNumber, pageSize } });
    return resp.data;
  },

  getById: async (taskId) => {
    const resp = await API.get(`tasks/${taskId}`);
    return resp.data;
  },

  post: async (taskPostDto) => {
    // const resp = await API.post(`tasks`, taskPostDto);

    // console.log(resp.response.data)

    // return resp.data;

    try {
      console.log('posting new task...', taskPostDto);
      const resp = await API.post(`tasks`, taskPostDto);
      return resp.data;
    } catch (error) {
      console.log(error.response.data);
    }
  },

  put: async (taskPutDto) => {
    const resp = await API.post(`tasks/${taskPutDto.id}`, taskPutDto);
    return resp.data;
  },

  delete: async (taskId) => {
    const resp = await API.delete(`tasks/${taskId}`);
    return resp.data;
  }
};

export default TaskService;