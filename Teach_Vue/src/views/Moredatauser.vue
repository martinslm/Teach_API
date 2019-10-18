<template>
  <div class="Moredatauser">
    <h1>Complete seus dados</h1>
    <input type="text" name="name" placeholder="Name..." />
    <br />
    <span class="label-input100">Nome do seu usuário</span>
    <input type="text" name="username" placeholder="Username..." />
    <br />
    <span class="label-input100">Data de Nascimento</span>
    <input type="text" name="datanascimento" placeholder="Data de Nascimento" />
    <br />
    <span class="label-input100">Gênero</span>
    <input type="text" name="genero" placeholder="Genero..." />
    <br />
    <span class="label-input100">Foto</span>
    <input type="text" name="foto" placeholder="Foto..." />
    <br />
    <span class="label-input100">Idioma Materno</span>
    <input type="text" name="idiomamaterno" placeholder="Idioma materno" />
    <br />
    <span class="label-input100">Idioma que deseja praticar</span>
    <input type="text" name="idiomapraticas" placeholder="Idioma que deseja praticar..."/>
    <br />
    <span class="label-input100">Sabe falar outro idioma? Se sim qual?</span>
    <input type="text" name="outroidioma" placeholder="Sabe falar outro idioma?..."/>
    <br />
    <span class="label-input100">Universidade</span>
    <input type="text" name="universidade" placeholder="Universidade..." />
    <br />
    <span class="label-input100">Área de estudo</span>
    <input type="text" name="areadeestudo" placeholder="Area de estudo..." />
    <br />
    <button @click="moredatauser">Finalizar</button>
  </div>
</template>

<script>
export default {
  name: "moredatauser",
  data() {
    return {
      name: "",
      username: "",
      datanascimento: "",
      genero: "",
      foto: "",
      idiomamaterno: "",
      idiomapraticas: "",
      outroidioma: "",
      universidade: "",
      areadeestudo: "",
    };
  },
  methods: {
    moredatauser() {
      completeconta
        .auth()
        .completedatauser(this.email, this.senha)
        .then(
          user => {
            this.$router.replace("home");
          },
          err => {
            alert("Aconteceu algo invesperado. " + err.message);
          }
        );
    }
  }
};
</script>

<style scoped>
.moredatauser {
  margin-top: 40px;
}
input {
  margin: 10px 0;
  width: 20%;
  padding: 15px;
}
button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #1606f3;
  border: 0;
  padding: 15px;
  color: #ffffff;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
span {
  display: block;
  margin-top: 20px;
  font-size: 11px;
}
</style>