<template>
  <div class="row justify-content-center">
    <div class="col-lg-5 col-md-7">
      <div class="card bg-secondary shadow border-0">
        <div class="card-header bg-transparent pb-5">
          <!--
                    <div class="text-muted text-center mt-2 mb-3">
                        <small>Entrar com</small>
                    </div>
                    
                    <div class="btn-wrapper text-center">
                        <a href="#" class="btn btn-neutral btn-icon">
                            <span class="btn-inner--icon"><img src="img/icons/common/google.svg"></span>
                            <span class="btn-inner--text">Google</span>
                        </a>
                    </div>
                </div>
                <div class="card-body px-lg-5 py-lg-5">
                    <div class="text-center text-muted mb-4">
                        <small>Ou insira suas credenciais abaixo</small>
                    </div>
          -->
          <form role="form">
            <base-input
              class="input-group-alternative mb-3"
              placeholder="Nome"
              addon-left-icon="ni ni-hat-3"
              v-model="model.nome"
            ></base-input>

            <base-input
              class="input-group-alternative mb-3"
              placeholder="Email"
              addon-left-icon="ni ni-email-83"
              v-model="model.email"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Senha"
              type="password"
              addon-left-icon="ni ni-lock-circle-open"
              v-model="model.senha"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Data de Nascimento"
              type="date"
              addon-left-icon="ni ni-calendar-grid-58"
              v-model="model.datanascimento"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Gênero"
              type="text"
              addon-left-icon="ni ni-single-02"
              v-model="model.genero"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Idioma Materno"
              type="text"
              addon-left-icon="ni ni-world"
              v-model="model.idiomamaterno"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Idioma que deseja praticar"
              type="text"
              addon-left-icon="ni ni-world"
              v-model="model.idiomapratica"
            ></base-input>

            <base-select
              placeholder="Área de domínio"
              type="option"
              addon-left-icon="ni ni-hat-3"
              v-model="model.areadominio"
            >
              <option v-for="areasgerais of areasgerais" :key="areasgerais.id">{{areasgerais}}</option>
            </base-select>

            <base-input
              class="input-group-alternative"
              placeholder="Área de aprendizado"
              type="text"
              addon-left-icon="ni ni-collection"
              v-model="model.areaaprendizado"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Assunto que deseja aprender"
              type="text"
              addon-left-icon="ni ni-books"
              v-model="model.assuntoaprender"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Como deseja conversar?"
              type="select"
              addon-left-icon="ni ni-chat-round"
              v-model="model.conversa"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Universidade"
              type="select"
              addon-left-icon="ni ni-paper-diploma"
              v-model="model.universidade"
            ></base-input>

            <base-input
              class="input-group-alternative"
              placeholder="Área de estudo"
              type="text"
              addon-left-icon="ni ni-books"
              v-model="model.areaestudo"
            ></base-input>
            <!--
                        <div class="text-muted font-italic">
                            <small>password strength: <span class="text-success font-weight-700">strong</span></small>
                        </div>
                        
                        <div class="row my-4">
                            <div class="col-12">
                                <base-checkbox class="custom-control-alternative">
                                    <span class="text-muted">I agree with the <a href="#!">Privacy Policy</a></span>
                                </base-checkbox>
                            </div>
                        </div>
            -->
            <div class="text-center">
              <base-button type="primary" class="my-4">Criar conta</base-button>
            </div>
          </form>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-6">
          <a href="#" class="text-light">
            <small>Esqueceu sua senha?</small>
          </a>
        </div>
        <div class="col-6 text-right">
          <router-link to="/login" class="text-light">
            <small>Entrar com sua conta</small>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    name: 'register',
    data() {
      return {
        model: {
          name: '',
          email: '',
          password: '',
          datanascimento: '',
          genero: '',
          idiomamaterno: '',
          idiomapraticas: '',
          areadominio: '',
          areaaprendizado: '',
          assuntoaprender: '',
          conversa: '',
          universidade: '',
          areaestudo: '',
        }
      }
    }
  }

import areaEstudo from './service/areaestudo'
export default {

data(){
return{
//aqui ele vai retornar pra tua pagina html todas as areas gerais
areasgerais: []}
},
mounted(){
//para testar o retorno
  areaEstudo.listarAreasGerais().then(resposta => {
console.log(resposta)
//aqui os dados de retorno
this.areasgerais = resposta.data
})
}
}
</script>
<style>
</style>
