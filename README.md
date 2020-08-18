# Feature Flag Toolkit

>This is an Excella Consultant Productivity Toolkit - it is intended to provide guidance and assistance to Excella's consultants. If you are a member of the Excella community, feel free to contribute!

## Overview

[Excella](https://www.excella.com/) is committed to **Continuous and Progressive Development** of software for our clients. One of the key components of Progressive Delivery is _Feature Flags_ (also known as _Feature Toggles_), the ability to dynamically enable and disable functionality of an application. This toolkit provides examples for developers on how to implement this pattern.

For a more thorough overview of Feature Flags, refer to [FeatureFlags.io](https://featureflags.io/)

## Platform

Excella is a polyglot organization - we support multiple programming languages and stacks. For a generalized Feature Flag solution, we are looking for an _open-source, deployable, and language-agnostic_ service. Our current solution of choice is [Flagr](https://checkr.github.io/flagr/). Flagr is a standalone service with both a [REST](https://en.wikipedia.org/wiki/Representational_state_transfer) interface and a simple graphical user interface.

In this repository you will find examples of how to integrate with Flagr in the following languages:


* [Java](https://github.com/excellaco/feature-flag-toolkit/blob/master/java/README.md)
* [.NET](https://github.com/excellaco/feature-flag-toolkit/blob/master/dotnet/README.md)
* [Python](https://github.com/excellaco/feature-flag-toolkit/blob/master/python/README.md)
* [Ruby](https://github.com/excellaco/feature-flag-toolkit/blob/master/ruby/README.md)

## Best Practices

### Targeted Rollouts

A pattern that has been successful with our clients is a _targeted user rollout_ of features. Instead of feature being all-or-nothing, it could be enabled for a specific subset of users and not others.

For example, imagine an internal application for an organization that is used in multiple departments. In order to manage training and expectations, it would be helpful to deploy new features only to users that have received training on them. We can add configuration for this into Flagr to avoid cluttering up our application code with logic around specific departments that will change over time. For a more detailed example, see here (TODO: Link)

### Testing

>Recommendations for testing go here

### Managing Tech Debt

> Info on how to remove flags after the fact

### Security and Change Management

> Info on how to work with client concerns
