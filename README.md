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

#### Unit Tests
Unit testing with feature flags should be simple. Best practice is to make each unit of code small enough that it is not aware of or affected by any feature flags. You can see a psuedocode example of doing unit tests with feature flags on [launchdarkly](https://launchdarkly.com/blog/testing-with-feature-flags/#TestingwithFeatureFlags-UnitTesting). If you are in a situation where a unit of code must know about a feature flag, you can simply mock out the feature flag inside of the unit test.

#### Integration Tests / E2E testing
It gets more difficult to run integration and E2E tests with feature flags. Since each flag has different combinations you must test, as you add more and more feature flags you begin to experience [combinatorial explosion](https://www.freecodecamp.org/news/combinatorics-handle-with-care-ed808b48e5dd/). It is still possible to test combinations but it should only be done for situations where you know one flag would definitely affect another. Other than that, you should find a different testing strategy that still gives your team confidence without attempting to test every combination of flag states. 

You can read more about other testing strategies in the blog posts below:

[launchdarkly](https://launchdarkly.com/blog/testing-with-feature-flags/), 
[optimizely #1](https://blog.optimizely.com/2019/02/11/using-feature-flags-to-test-in-production/),
[optimizely #2](https://blog.optimizely.com/2020/06/04/best-practices-feature-flag-testing-qa/)

### Managing Tech Debt

When integrating Feature Flags into your application, you will create a set of *Guards*, code blocks that determine access to your feature (usually in the form of an `if` statement or similar structure). It is important to remove these guards once a feature has been fully promoted, both for code cleanliness and safety. With the speed of agile development, removing these guards can be forgotten or deprioritized. Here are some tips for ensuring they are removed.

* For each feature, use only a single guard if possible, two to three at most. If you find that it takes more than three guards to isolate your feature, its likely there is a design flaw in your feature implementation. 
* Add a comment next to your guard with an easily searchable tag for the name of the feature.
* If possible, create a branch / pull request that removes the guard at the same time that the guard is implemented. In the best case scenario, this allows the guard to be removed in a single merge. Worst case - you've provided a guide on how to remove the guard.
* Immediately create a ticket / card in whatever agile framework you are using to represent the work of removing the guard, and make sure it stays visible in the backlog to be picked up as soon as the feature is fully promoted. 

### Security and Change Management

> Info on how to work with client concerns
