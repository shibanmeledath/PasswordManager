import axios from 'axios';
const api = axios.create({
    baseURL: "https://localhost:7209/api/PasswordManager/",
    headers: {'Content-type':'application/json'}
});
export default api;