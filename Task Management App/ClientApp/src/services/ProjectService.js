import API from './API';

const ProjectService = {
  get: async function (param) {
    const resp = await API.get('projects', { params: param});
    return resp.data;
  },

  getById: async (projectId) => {
    const resp = await API.get(`projects/${projectId}`);
    return resp.data;
  },

  post: async (projectPostDto) => {
    const resp = await API.post(`projects`, projectPostDto);
    return resp.data;
  },

  put: async (projectPutDto) => {
    const resp = await API.post(`projects/${projectPutDto.id}`, projectPutDto);
    return resp.data;
  },

  delete: async (projectId) => {
    const resp = await API.delete(`projects/${projectId}`);
    return resp.data;
  }
};

export default ProjectService;