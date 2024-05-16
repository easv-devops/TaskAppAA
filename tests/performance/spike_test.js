import http from "k6/http";
import { sleep } from "k6";

export const options = {
    stages: [
        { duration: "10s", target: 100 },
        { duration: "1m", target: 100 },
        { duration: "10s", target: 1400 },
        { duration: "3m", target: 1400 },
        { duration: "10s", target: 100 },
        { duration: "3m", target: 100 },
        { duration: "10s", target: 0 },
    ],
};

export default () => {
    http.get("http://5.189.170.247:5002/api/tasks");
    sleep(1);
};