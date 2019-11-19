import { http } from "./config";

export default {
  efetuarLogin: (loginForm) => {
    return http.post("usuario/fazerlogin", loginForm);
    }
  };