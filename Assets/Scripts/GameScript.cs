using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person {
    private HashSet<Person> PersonLikes = new HashSet<Person>();
    private HashSet<Person> PersonDislikes = new HashSet<Person>();
    public readonly string Name;

    public Person(string name)
    {
        Name = name;
    }

    public int calculateScore(ICollection<Person> people) {
        int score = 0;
        foreach (Person person in people)
        {
            if (PersonLikes.Contains(person))
            {
                score = 1;
            }
            if (PersonDislikes.Contains(person))
            {
                return -2;
            }
        }
        return score;
    }
}

public class GameScript : MonoBehaviour {

    // Seated People : Array
    // Unseated People : Queue
    [SerializeField]
    private string[] FirstNames = { };

    [SerializeField]
    private string[] LastNames = { };

    [SerializeField]
    private float PersonDelay = 5;

    [SerializeField]
    private int MaximumQueued = 3;

    public HashSet<Person> SeatedPeople = new HashSet<Person>();
    public Queue<Person> ToBeSeated = new Queue<Person>();

    private float timeRemaining = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;
        timeRemaining -= deltaTime;
        while (timeRemaining <= 0 && PersonDelay > 0)
        {
            timeRemaining += PersonDelay;
            PersonArrives();
        }
	}

    void PersonArrives()
    {
        if(ToBeSeated.Count < MaximumQueued)
        {
            string firstName = FirstNames[Random.Range(0, FirstNames.Length)];
            string lastName = LastNames[Random.Range(0, LastNames.Length)];
            Person p = new Person(firstName + " " + lastName);

            // Add liked and disliked people

            ToBeSeated.Enqueue(p);
            Debug.Log("Queued " + p.Name);
        } else
        {
            PersonLeft();
        }
    }

    //Deduct points for person leaving
    void PersonLeft()
    {

    }
}
