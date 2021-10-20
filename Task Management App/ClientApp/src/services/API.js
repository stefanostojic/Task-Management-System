import axios from 'axios';

export default axios.create({
  baseURL: `http://localhost:54720/api/`
});
