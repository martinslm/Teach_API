<template>
    <div>
        <base-header class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center"
                     style="min-height: 600px; background-image: url(img/theme/profile-cover.jpg); background-size: cover; background-position: center top;">
            <!-- Mask -->
            <span class="mask bg-gradient-success opacity-8"></span>
            <!-- Header container -->
            <div class="container-fluid d-flex align-items-center">
                <div class="row">
                    <div class="col-lg-7 col-md-10">
                        <h1 class="display-2 text-white">Olá</h1>
                        <p class="text-white mt-0 mb-5">Esta é sua página, onde você pode ver o progresso e gerenciar seus cursos</p>
                        <a href="#!" class="btn btn-info">Editar perfil</a>
                    </div>
                </div>
            </div>
        </base-header>
    <div id="Relatorio">
        <h1 class="display-2 text-white">Temos sugestões para você</h1>
        <table>
            <thead>
                <tr>
                    <th width="20%">Nome</th>
                    <th width="16%">Idade</th>
                    <th width="20%">Idiomas</th>
                    <th width="20%">Dominínio sobre</th>
                    <th width="20%">Quer aprender sobre</th>
                    <th width="4%"></th>
                </tr>
            </thead>
            <tbody>

                <template v-for="objeto in sugestaoUsuarios">
                
                <tr>
                <th width="20%">{{objeto.nome}}</th>
                <th width="16%">{{calcula(objeto.dataNascimento)}}</th>
                <th width="20%">{{objeto.idiomaOrigem.descricao}}, {{objeto.idiomaParaAprender.descricao}} e {{objeto.idiomaFluenteSecundario.descricao}}</th>
                <th width="20%">{{objeto.areaEstudoDominioGeral.descricao}} - {{objeto.areaEstudoDominioEspecifica.descricao}}</th>
                <th width="20%">{{objeto.areaEstudoParaAprenderGeral.descricao}} - {{objeto.areaEstudoParaAprenderEspecifico.descricao}}</th>
                <th width="4%"></th>
                </tr>

                </template>

            </tbody>
        </table>
    </div>


        <div class="container-fluid mt--7" v-show="false">
            <div class="row">
                <div class="col-xl-4 order-xl-2 mb-5 mb-xl-0">

                    <div class="card card-profile shadow">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <img src="img/theme/team-4-800x800.jpg" class="rounded-circle">
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <div class="d-flex justify-content-between">
                                <base-button size="sm" type="info" class="mr-4">Connect</base-button>
                                <base-button size="sm" type="default" class="float-right">Message</base-button>
                            </div>
                        </div>
                        <div class="card-body pt-0 pt-md-4">
                            <div class="row">
                                <div class="col">
                                    <div class="card-profile-stats d-flex justify-content-center mt-md-5">
                                        <div>
                                            <span class="heading">22</span>
                                            <span class="description">Friends</span>
                                        </div>
                                        <div>
                                            <span class="heading">10</span>
                                            <span class="description">Photos</span>
                                        </div>
                                        <div>
                                            <span class="heading">89</span>
                                            <span class="description">Comments</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center">
                                <h3>
                                    Cliente<span class="font-weight-light">, 27</span>
                                </h3>
                                <div class="h5 font-weight-300">
                                    <i class="ni location_pin mr-2"></i>Brazil, Joinville
                                </div>
                                <div class="h5 mt-4">
                                    <i class="ni business_briefcase-24 mr-2"></i>CEO Teach
                                </div>
                                <div>
                                    <i class="ni education_hat mr-2"></i>Unisociesc
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>
<script>
import swal from "sweetalert2";
import pesquisa from "../../../services/sugestoes";
import { mapState } from "vuex";

export default {
  name: "Register",
  data() {
    return {
     sugestaoUsuarios: [],
     idUsuario: "",
     dataAtual: new Date()
    };
  },
  methods: {
      calcula(dobString) {

                        var dob = new Date(dobString);
                var currentDate = new Date();
                var currentYear = currentDate.getFullYear();
                var birthdayThisYear = new Date(currentYear, dob.getMonth(), dob.getDate());
                var age = currentYear - dob.getFullYear();
                if(birthdayThisYear > currentDate) {
                    age--;
                }
                return age;
                }
  },
  mounted() {

    this.idUsuario = localStorage.getItem("idusuario"); 

     pesquisa.obterSugestoes(this.idUsuario).then(resposta => {
      console.log(resposta);
      //aqui os dados de retorno
      this.sugestaoUsuarios = resposta.data.usuariosRecomendados;
    });
  }
};

</script>
<style></style>
