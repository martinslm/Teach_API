import { http } from "./config";

export default {
  efetuarLogin: (loginForm) => {
    return http.get("usuario/fazerlogin", {params: {loginForm}});
  }
};