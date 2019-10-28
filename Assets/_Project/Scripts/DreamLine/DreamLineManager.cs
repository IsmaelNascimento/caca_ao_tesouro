using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;

public class DreamLineManager : MonoBehaviour
{
    [Header("Interface User")]
    [SerializeField] private Text m_TextQuestion;
    [SerializeField] private InputField m_InputAnswers;
    [SerializeField] private InputField m_InputAgeUser;
    [SerializeField] private GameObject m_PanelContratulations;
    [SerializeField] private GameObject m_PanelScreenAge;
    [SerializeField] private VideoClip m_AgeBigger14;
    [SerializeField] private VideoClip m_AgeSmaller14;

    [Header("Video Player")]
    [SerializeField] private RawImage m_ShowVideo;
    [SerializeField] private VideoPlayer m_VideoPlayer;

    private int m_IndexQuestion = 0;
    private List<string> m_Questions = new List<string>()
    {
        "Qual seu sonho ?",
        "O que tem que acontecer um passo antes ?",
        "O que tem que acontecer um passo antes ?",
        "O que tem que acontecer um passo antes ?",
        "O que tem que acontecer um passo antes ?",
        "Qual seu momento atual ?"
    };

    private Dictionary<int, string> m_AnswersUser = new Dictionary<int, string>();

    public void OnButtonNextQuestionCliked()
    {
        m_AnswersUser[m_IndexQuestion] = m_InputAnswers.text;

        if(m_IndexQuestion == (m_Questions.Count-1))
        {
            SendEmail();
            m_PanelContratulations.SetActive(true);
            ShowVideoCongratulations();
            return;
        }

        m_IndexQuestion++;
        m_InputAnswers.text = string.Empty;
        m_TextQuestion.text = m_Questions[m_IndexQuestion];
    }

    private void SendEmail()
    {
        var answers = "";

        for (int i = 0; i < m_Questions.Count; i++)
        {
            answers += string.Format("Pergunta: {0}\nResposta: {1}\n", m_Questions[i], m_AnswersUser[i]);
        }

        var subjectEmail = "Acompanhameto Caça ao Tesouro";
        var bodyEmail = string.Format("Respostas do aluno {0} no jogo: Linhas do Sonho.\n \n{1}", InformationEmailManager.nameStudent, answers);

        SimpleEmailSender.Send(InformationEmailManager.emailTeacher, subjectEmail, bodyEmail, "", (x, y) => print("Send"));
        SimpleEmailSender.Send("falecom@cresceraprendendo.com.br", subjectEmail, bodyEmail, "", (x, y) => print("Send"));
    }

    private void ShowVideoCongratulations()
    {
        StartCoroutine(ShowVideoCongratulations_Coroutine());
    }

    private IEnumerator ShowVideoCongratulations_Coroutine()
    {
        m_VideoPlayer.EnableAudioTrack(0, true);
        m_VideoPlayer.SetTargetAudioSource(0, m_VideoPlayer.gameObject.GetComponent<AudioSource>());

        if (InformationEmailManager.ageStudent >= 14)
        {
            m_VideoPlayer.clip = m_AgeBigger14;
        }
        else
        {
            m_VideoPlayer.clip = m_AgeSmaller14;
        }

        m_VideoPlayer.Prepare();

        while (!m_VideoPlayer.isPrepared)
        {
            yield return null;
        }

        m_ShowVideo.texture = m_VideoPlayer.texture;

        m_VideoPlayer.Play();

        m_VideoPlayer.gameObject.GetComponent<AudioSource>().Play();

        while (m_VideoPlayer.isPlaying)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("MenuGames");
    }
}