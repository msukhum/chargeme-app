/* eslint-disable no-undef */
// src/axios.js
import axios from 'axios';

const instance = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
    timeout: 10000,
    headers: { 'Content-Type': 'application/json' }
});

export default instance;
