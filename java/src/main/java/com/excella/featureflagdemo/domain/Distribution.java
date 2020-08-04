package com.excella.featureflagdemo.domain;

public class Distribution {
  private int id;
  private int percent;
  private String variantKey;
  private int variantID;

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public int getPercent() {
    return percent;
  }

  public void setPercent(int percent) {
    this.percent = percent;
  }

  public String getVariantKey() {
    return variantKey;
  }

  public void setVariantKey(String variantKey) {
    this.variantKey = variantKey;
  }

  public int getVariantID() {
    return variantID;
  }

  public void setVariantID(int variantID) {
    this.variantID = variantID;
  }
}
