import http from "k6/http";
import { sleep } from "k6";

export const options = {
    stages: [
        { duration: "5m", target: 100 },
        { duration: "10m", target: 100 },
        { duration: "5m", target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(99)<150'],
    },
};

export default () => {
    http.get("http://5.189.170.247:5002/api/tasks");
    sleep(1);
};