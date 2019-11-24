<template>
  <div>
    <!-- Header
    <div class="header bg-purple py-7 py-lg-8 pt-lg-9">
      <div class="container">
        <div class="header-body text-center mb-5">
          <div class="row justify-content-center">
            <div class="col-xl-5 col-lg-6 col-md-8 px-5">
              <h1 class="text-white">
                Crie uma conta
              </h1>
            </div>
          </div>
        </div>
      </div>
      <div class="separator separator-bottom separator-skew zindex-100">
        <svg
          x="0"
          y="0"
          viewBox="0 0 2560 100"
          preserveAspectRatio="none"
          version="1.1"
          xmlns="http://www.w3.org/2000/svg">
          <polygon
            class="fill-default"
            points="2560 0 2560 100 0 100"/>
        </svg>
      </div>
    </div>-->
    <!-- Page content -->
    <div class="container mt--8 pb-5">
      <!-- Table -->
      <div class="row justify-content-center">
        <div class="col-lg-12 col-md-12">
          <div class="card bg-secondary border-0">
            <div class="card-header bg-transparent">
              <div class="text-center mt-2 mb-2">Para criar sua conta, informe os dados abaixo</div>
            </div>
            <div class="card-body px-lg-12 py-lg-12">
              <form class="needs-validation">
                <base-input
                  v-validate="'required|min:3|max:32'"
                  v-model="objetoAPI.Nome"
                  :error="getError('nome')"
                  :valid="isValid('nome')"
                  name="nome"
                  class="mb-3"
                  prepend-icon="ni ni-single-02"
                  placeholder="Nome"
                  addon-left-icon="ni ni-hat-3"
                />

                <base-input
                  v-validate="'required|email|min:12|max:64'"
                  v-model="objetoAPI.Email"
                  :error="getError('e-mail')"
                  :valid="isValid('e-mail')"
                  name="e-mail"
                  class="mb-3"
                  prepend-icon="ni ni-email-83"
                  placeholder="E-mail"
                  addon-left-icon="ni ni-email-83"
                />

                <base-input
                  v-model="objetoAPI.Telefone"
                  name="telefone"
                  class="mb-3"
                  placeholder="Telefone"
                />

                <base-input
                  v-validate="'required|min:8|max:64'"
                  v-model="objetoAPI.Senha"
                  :error="getError('senha')"
                  :valid="isValid('senha')"
                  name="senha"
                  class="mb-3"
                  prepend-icon="ni ni-lock-circle-open"
                  placeholder="Senha"
                  type="password"
                  addon-left-icon="ni ni-lock-circle-open"
                />

                <!-- <password-strength :password="registerForm.password" /> -->

                <base-input
                  v-validate="'required'"
                  v-model="objetoAPI.DataNascimento"
                  :error="getError('Data de Nascimento')"
                  :valid="isValid('Data de Nascimento')"
                  name="Data de Nascimento"
                  class="mb-3"
                  prepend-icon="ni ni-date-button"
                  placeholder="Data de Nascimento"
                  type="date"
                  addon-left-icon="ni ni-calendar-grid-58"
                />

                <label>Selecione seu sexo:  </label> 
                <select v-model="objetoAPI.Genero">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.genero"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <label>Qual seu idioma natal? </label> 
                <select v-model="objetoAPI.IdIdiomaOrigem">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.idiomas"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <label>Selecione um segundo idioma (Se você não fala outro idioma, selecione o seu idioma natal): </label> 
                <select v-model="objetoAPI.IdIdiomaDominio">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.idiomas"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <label>Qual idioma você deseja praticar? </label> 
                <select v-model="objetoAPI.IdIdiomaAprendizado">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.idiomas"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <label>Onde você estuda? </label> 
                <select v-model="objetoAPI.Universidade">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.universidade"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <label>Selecione uma área que você possua domínio para ensinar:  </label> 
                <select v-on:change="AreaEstudoDominioSelecionada" v-model="objetoAPI.IdAreaEstudoGeralDominio">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.areasgerais"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br>

                <div  v-show="objetoAPI.IdAreaEstudoGeralDominio != ''">
                <label>Dentro dessa área, qual assunto você mais domina? </label> 
                <select v-model="objetoAPI.IdAreaEstudoEspecificoDominio">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.areasespecificasdominio"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br></div>

                <label>Selecione uma área que você gostaria de aprender:  </label> 
                <select v-on:change="AreaEstudoDominioSelecionadaAprender" v-model="objetoAPI.IdAreaEstudoGeralAprendizado">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.areasgerais"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select>

                <div  v-show="objetoAPI.IdAreaEstudoGeralAprendizado != ''">
                <label>Dentro dessa área, qual assunto você tem mais interesse? </label> 
                <select v-model="objetoAPI.IdAreaEstudoEspecificoAprendizado">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.areasespeficiasaprendizado"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select><br></div>

                <br>
                <label>Como você prefere conversar?  </label> 
                <select v-model="objetoAPI.TipoIteracao">
                  Escolha um item
                  <option
                    v-for="objeto in registerForm.preferenciaConversa"
                    :key="objeto.id"
                    :value="objeto.id"
                  >{{ objeto.descricao }}</option>
                </select>
            
                <!--
                <div class="row my-4">
                  <div class="col-12">
                    <base-checkbox v-model="registerForm.agree">
                      <span class="text-muted">
                        Eu li e aceito a <a href="#!">Política de Privacidade</a>
                      </span>
                    </base-checkbox>
                    <div v-show="!registerForm.agree && triedSubmit"
                         class="invalid-feedback"
                         style="display: block;">
                      Você deve aceitar os termos de uso.
                    </div>
                  </div>
                </div>
                -->

                <api-errors
                  :multiple-errors="registerErrors"
                  :alert-classes="'py-2 mb-1'"
                  dismissible
                />

                <div class="text-center">
                  <base-button
                    :disabled="registering"
                    type="primary"
                    size="lg"
                    class="mt-1 btn-block"
                    @click="registrarUsuario()"
                  >Registrar</base-button>
                </div>
              </form>
            </div>
          </div>
          <div class="row mt-3">
            <!--
            <div class="col-6">
              <router-link to="/home" class="text-light">
                <small>Início</small>
              </router-link>
            </div>
            -->
            <div class="col-8 text-right">
              <router-link to="/login" class="text-light">
                <small>Já possui uma conta? Clique aqui e faça seu login</small>
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
import areaEstudo from "../../../services/areaestudo";
import idioma from "../../../services/idioma";
import universidadeService from "../../../services/universidade";
import usuario from "../../../services/usuario";
import { mapState } from "vuex";

export default {
  name: "Register",
  data() {
    return {
      objetoAPI: {
      Genero: "",
      IdAreaEstudoGeralDominio: "",
      IdAreaEstudoGeralAprendizado: "",
      TipoIteracao: "",
      IdIdiomaOrigem: "",
      IdIdiomaAprendizado: "",
      IdIdiomaDominio: "",
      Universidade: "",
      IdAreaEstudoEspecificoDominio: "",
      IdAreaEstudoEspecificoAprendizado: "",
      DataNascimento: "",
      Senha: "",
      Email: "",
      Nome: "",
      Telefone: ""
      },
      triedSubmit: false,
      retornoAPI: "",
      mensagemAPI: "",
      registerForm: {
        genero: [{id: 1, descricao: "Feminino"}, {id: 2, descricao: "Masculino"}, {id:3, descricao: "Indefinido"}],
        idiomas: [],
        idiomapratica: [],
        preferenciaConversa: [{id: 1, descricao: "Chat"}, {id: 2, descricao: "Voz"}, {id:3, descricao: "Video"}],
        universidade: [],
        areasgerais: [],
        areasespecificasdominio: [],
        areasespeficiasaprendizado: []
      }
    };
  },
  mounted() {
    //para testar o retorno
    areaEstudo.listarAreasGerais().then(resposta => {
      console.log(resposta);
      //aqui os dados de retorno
      this.registerForm.areasgerais = resposta.data.areasEstudo;
    });

    universidadeService.listarUniversidades().then(resposta => {
      console.log(resposta);
      this.registerForm.universidade = resposta.data.universidades;
    });

    idioma.listarIdiomas().then(resposta => {
      console.log(resposta);
      this.registerForm.idiomas = resposta.data.idiomas;
    });
  },
  computed: {
    ...mapState({
      registerErrors: state => state.account.status.registerErrors,
      registering: state => state.account.status.isRegistering
    })
  },
  methods: {

    handleSubmit(e) {
      this.$validator.validate().then(valid => {
        if (!this.registerForm.agree) {
          this.triedSubmit = true;
        } else if (valid) {
          this.$store.dispatch("account/register", this.registerForm);
        }
      });
    },
    showAlert(title) {
      swal({
        title,
        buttonsStyling: false,
        confirmButtonClass: "btn btn-success btn-fill"
      });
    },

    AreaEstudoDominioSelecionada() {
       areaEstudo.listarAreasEspecificas(this.objetoAPI.IdAreaEstudoGeralDominio).then(resposta => {
      this.registerForm.areasespecificasdominio = resposta.data.areasEstudo;

    });
    },
    AreaEstudoDominioSelecionadaAprender()
    {
      areaEstudo.listarAreasEspecificas(this.objetoAPI.IdAreaEstudoGeralAprendizado).then(resposta => {
      this.registerForm.areasespeficiasaprendizado = resposta.data.areasEstudo;
    });
    },
    getError(name) {
      if (this.errors) return this.errors.first(name);
      else return "";
    },
    isValid(name) {
      return this.validated && !this.errors.has(name);
    },
    registrarUsuario(){

      var retorno = usuario.cadastrarUsuario(this.objetoAPI);

      retorno.then(resposta => {
        console.log(resposta);
        this.mensagemAPI = resposta.data.mensagem;
        this.retornoAPI = resposta.data.sucesso;

        if(this.retornoAPI)
        {
        alert("Usuário cadastrado com sucesso.");
        window.location.href = "/Login";
        }
        else
        alert(this.mensagemAPI);
      });
    }
  }
};
</script>
<style scoped></style>
