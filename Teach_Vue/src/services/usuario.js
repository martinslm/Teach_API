import { http } from "./config";

export default {
  efetuarLogin: (loginForm) => {
    return http.get("usuario/fazerlogin", {
        headers: {
        'Content-Type': 'application/json'
        }
});
    }
  };