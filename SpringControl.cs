using UnityEngine;

public class SpringControl : MonoBehaviour
{
    public CustomSlider elasticitySlider;
    public CustomSlider weightSlider;
    public CustomSlider decaySlider;
    public SpringSimulation springSimulation;

    void Start()
    {
        if (elasticitySlider != null)
        {
            elasticitySlider.OnCustomValueChanged += OnElasticityChange;
            elasticitySlider.value = springSimulation.elasticity;
        }

        if (weightSlider != null)
        {
            weightSlider.OnCustomValueChanged += OnWeightChange;
            weightSlider.value = springSimulation.weight;
        }

        if (decaySlider != null)
        {
            decaySlider.OnCustomValueChanged += OnDecayChange;
            decaySlider.value = springSimulation.decay;
        }
    }

    void OnElasticityChange()
    {
        springSimulation.elasticity = elasticitySlider.value;
        springSimulation.RestartOscillation();
    }

    void OnWeightChange()
    {
        springSimulation.weight = weightSlider.value;
        springSimulation.RestartOscillation();
    }

    void OnDecayChange()
    {
        springSimulation.decay = decaySlider.value;
        springSimulation.RestartOscillation();
    }
}