package com.excella.featureflagdemo;

import com.excella.featureflagdemo.domain.Flag;
import com.excella.featureflagdemo.domain.Role;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.reactive.function.client.WebClient;
import reactor.core.publisher.Mono;

@Controller
public class FlagController {

  private WebClient webClient;

  public FlagController() {
    webClient = WebClient.create("http://localhost:18000/api/v1");
  }

  @GetMapping("/allFlags")
  public Mono<String> obtainAllFlags(Model model) {
    return webClient
        .get().uri("/flags").exchange()
        .flatMapMany(resp -> resp.bodyToFlux(Flag.class))
        .collectList()
        .map(list -> model.addAttribute("flags", list))
        .thenReturn("allFlags");
  }

  @GetMapping("/userFlags")
  public Mono<String> obtainUserFlags(Model model, Authentication authentication) {

    UserDetails principal = (UserDetails) authentication.getPrincipal();

    String userName = authentication.getName();
    String roleName = principal.getAuthorities()
                        .stream()
                        .map(GrantedAuthority::getAuthority)
                        .findFirst()
                        .orElse("NOT FOUND");

    model.addAttribute("username", userName);
    model.addAttribute("rolename", roleName);

    return Mono.just("userFlags");

  }

}
