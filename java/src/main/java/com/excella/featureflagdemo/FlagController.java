package com.excella.featureflagdemo;

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
        .flatMap(resp -> resp.bodyToMono(String.class))
        .map(json -> model.addAttribute("flags", json))
        .map(ignore -> "allFlags");
  }

}
