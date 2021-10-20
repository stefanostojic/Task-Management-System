import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    vus: 10000, 
    duration: '10s'
};

export default () => {
    http.get('http://localhost:54720/api/projects');
};