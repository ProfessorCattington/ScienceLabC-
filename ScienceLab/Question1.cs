using System;
using System.Collections.Generic;
using System.IO;

namespace ScienceLab
{
public class Question1
{
    string inputFilePath = "C:\\Users\\Mike\\Documents\\org_chart.in";
    string outputFilePath = "C:\\Users\\Mike\\Documents\\org_chart_sample.out";

    public Question1(){}

    public void RunQuestion()
    {
        string[] textData = LoadInputFromFile(inputFilePath);

        if (textData != null)
        {
            Dictionary<int,List<TeamMember>> cases;

            cases = ConvertInputIntoOrgStruct(textData);

            List<string> output = new List<string>();
            output = FormatOutput(cases);
            SendOutputToFile(outputFilePath, output);
        }
    }

    private static string[] LoadInputFromFile(string filePath)
    {

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            return lines;

        }
        else
        {
            Console.WriteLine("could not find file at: " + filePath);
            return null;
        }
    }

    private Dictionary<int, List<TeamMember>> ConvertInputIntoOrgStruct(string[] masterStrings) {

        Dictionary<int, List<TeamMember>> organizationCases = new Dictionary<int, List<TeamMember>>();

        string[] separators = { "--" }; //each individual is separated by a double dash

        int numberOfCases = int.Parse(masterStrings[0]);

            //run through each case and begin extracting team member information. start i at 1 since the first line was the number of cases
            for (int i = 1; i < numberOfCases + 1; i++)
            {
                string[] individualMemberStrings = masterStrings[i].Split(separators, System.StringSplitOptions.None);

                List<TeamMember> listTeamMembers = new List<TeamMember>();

                string[] infoSeparators = { "," };
                string[] individualMemberInfoStrings;

                for (int j = 0; j < individualMemberStrings.Length; j++)
                {
                    individualMemberInfoStrings = individualMemberStrings[j].Split(infoSeparators, System.StringSplitOptions.None);

                    TeamMember teamMember = new TeamMember();
                    teamMember.name = individualMemberInfoStrings[0];
                    teamMember.managerName = individualMemberInfoStrings[1];
                    teamMember.role = individualMemberInfoStrings[2];
                    teamMember.year = individualMemberInfoStrings[3];

                    teamMember.subordinates = new List<TeamMember>();

                    listTeamMembers.Add(teamMember);
                }

                //take our list of team members and find the managers
                //start with the CEO and then point all the team members to their managers

                TeamMember CEO = null;
                for (int j = 0; j < listTeamMembers.Count; j++) {

                    if (listTeamMembers[j].managerName == "NULL")
                    {
                        CEO = listTeamMembers[j];
                    }

                    for (int k = 0; k < listTeamMembers.Count; k++)
                    {
                        if(listTeamMembers[j].managerName == listTeamMembers[k].name)
                        {
                            listTeamMembers[k].subordinates.Add(listTeamMembers[j]);
                            listTeamMembers[j].reportsToMember = listTeamMembers[k];
                        }
                     }
                }

                foreach (TeamMember member in listTeamMembers)
                {
                    member.CEO = CEO;
                }

                organizationCases.Add(i, listTeamMembers);
        }

        return organizationCases;
    }

    private List<string> FormatOutput(Dictionary<int, List<TeamMember>> cases)
    {
        List<string> outputStrings = new List<string>();

        for (int i = 1; i < cases.Count + 1; i++)
        {

            outputStrings.Add("Case #" + i);

            //grab the CEO 
            List<TeamMember> teamMembers = cases[i];

            TeamMember currentMember = teamMembers[0].CEO;

            //begin recursively drilling into the subordinates. add their info to the output strings
            RecursiveSortAndFormat(0, currentMember, outputStrings);
        }
            
        return outputStrings;
    }

    private void RecursiveSortAndFormat(int occurance, TeamMember member, List<string> outputStrings)
    {
        occurance++;
        string outputString = "";

        //add some dashes to the outputstring for this member before sorting and moving downward
        for(int dashes = 0; dashes < occurance -1; dashes++)
        {
            outputString += "-";
        }
        outputString += member.name;
        outputString += " (" + member.role + ") ";
        outputString += member.year;

        Console.WriteLine(outputString);
        outputStrings.Add(outputString);

        //take the team members and organize them alphabetically
        bool swap = true;
        while (swap)
        {
            swap = false;
            List<TeamMember> subordinates = member.subordinates;

            for (int x = 0; x < subordinates.Count - 1; x++)
            {
                TeamMember tempMember;

                char charA = subordinates[x].name.ToCharArray()[0];
                char charB = subordinates[x + 1].name.ToCharArray()[0];

                if (charA > charB)
                {
                    tempMember = subordinates[x];
                    subordinates[x] = subordinates[x + 1];
                    subordinates[x + 1] = tempMember;
                    swap = true;
                }
            }

            member.subordinates = subordinates;
        }

        foreach (TeamMember subordinate in member.subordinates)
        {
            RecursiveSortAndFormat(occurance, subordinate, outputStrings);
        }
    }

    private void SendOutputToFile(string filePath, List<string> outputStrings)
    {

        StreamWriter streamWriter = new StreamWriter(filePath);

        foreach(string outputString in outputStrings)
        {
                streamWriter.WriteLine(outputString);
        }

        streamWriter.Close();
    }
}
}

