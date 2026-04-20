using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemExamples : MonoBehaviour
{
    private ParticleSystem ps;
    
    private void Start()
    {
        // Accessing Modules
        // Access the "main" module for core settings
        var main = ps.main; 
        main.startColor = Color.red;
        main.simulationSpeed = 2.0f;
        
        // Playback Control
        ps.Play();    // Starts the simulation
        ps.Pause();   // Freezes particles in place
        ps.Stop();    // Stops emitting, but existing particles finish their life
        ps.Clear();   // Instantly removes all active particles
        
        // Emits 10 particles instantly at the current position
        ps.Emit(10);
    }

    private void OnParticleSystemStopped()
    {
        Debug.Log("The system has finished and all particles are gone.");
        // Great place to ReturnToPool() or Destroy()
    }
    
    private IEnumerator PlayThenDestroy()
    {
        ps.Play();

        // Wait while the system is emitting OR has active particles
        while (ps.IsAlive(true)) 
        {
            yield return null;
        }

        Debug.Log("Effect finished!");
        Destroy(gameObject);
    }
    
    public void ExplosionBurst(int amount)
    {
        var emission = ps.emission;
    
        // Create a burst object
        ParticleSystem.Burst burst = new ParticleSystem.Burst(0.0f, (short)amount);
    
        // Apply to the emission module
        emission.SetBursts(new ParticleSystem.Burst[] { burst });
    
        ps.Play();
    }
    
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    void OnParticleCollision(GameObject other)
    {
        // Get details about where the particles hit
        int numCollisionEvents = ps.GetSafeCollisionEventSize();
        
        // This list is reused to save memory
        ps.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            Vector3 hitPoint = collisionEvents[i].intersection;
            Debug.Log($"Hit {other.name} at {hitPoint}");
            
            // Example: Apply damage if the hit object has a Health script
            if (other.TryGetComponent(out Rigidbody health)) {
                // health.AddExplosionForce();
            }
        }
    }
    
    void OnParticleTrigger()
    {
        // Particles that just entered the trigger zone
        List<ParticleSystem.Particle> entered = new List<ParticleSystem.Particle>();
    
        // Get the particles that triggered the event
        int numEntered = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, entered);

        for (int i = 0; i < numEntered; i++)
        {
            ParticleSystem.Particle p = entered[i];
            p.startColor = Color.green; // Turn them green when they enter
            entered[i] = p;
        }

        // Set them back for the changes to take effect
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, entered);
    }
    
}