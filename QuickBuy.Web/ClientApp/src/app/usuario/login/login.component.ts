import { Component } from "@angular/core";
import { Usuario } from "../../modelo/usuario";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})


export class LoginComponent {
  public usuario;

  constructor(private router: Router) {
    this.usuario = new Usuario();
  }

  public copyright = "Desenvolvido por: Marcio Brito";
  public email = "";
  public senha = "";

  acessar()
  {
    if (this.usuario.email == "marcio@outlook.com" && this.usuario.senha == "123") {
      sessionStorage.setItem("usuario-autenticado", "1");
      this.router.navigate(['/']);
    }


      
  }
}
