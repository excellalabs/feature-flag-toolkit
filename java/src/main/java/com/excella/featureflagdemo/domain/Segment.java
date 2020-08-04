package com.excella.featureflagdemo.domain;

import java.util.List;

public class Segment {

  private int id;
  private String description;
  private List<Constraint> constraints;
  private List<Distribution> distributions;
  private int rank;
  private int rolloutPercent;

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public String getDescription() {
    return description;
  }

  public void setDescription(String description) {
    this.description = description;
  }

  public List<Constraint> getConstraints() {
    return constraints;
  }

  public void setConstraints(List<Constraint> constraints) {
    this.constraints = constraints;
  }

  public List<Distribution> getDistributions() {
    return distributions;
  }

  public void setDistributions(List<Distribution> distributions) {
    this.distributions = distributions;
  }

  public int getRank() {
    return rank;
  }

  public void setRank(int rank) {
    this.rank = rank;
  }

  public int getRolloutPercent() {
    return rolloutPercent;
  }

  public void setRolloutPercent(int rolloutPercent) {
    this.rolloutPercent = rolloutPercent;
  }
}
