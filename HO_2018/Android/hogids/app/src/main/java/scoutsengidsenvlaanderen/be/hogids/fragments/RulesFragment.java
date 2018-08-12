package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import scoutsengidsenvlaanderen.be.hogids.LocalStorage;
import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link RulesFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class RulesFragment extends Fragment {

    TextView lblintro;
    TextView lblOutro;
    TextView lblTitle;

    public RulesFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment RulesFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static RulesFragment newInstance() {
        RulesFragment fragment = new RulesFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_rules, container, false);

        lblTitle = view.findViewById(R.id.leefregels_title);
        lblintro = view.findViewById(R.id.leefregels_intro);
        lblOutro = view.findViewById(R.id.leefregels_outro);

        lblTitle.setText(LocalStorage.getInstance().getCopy("Rules_Title"));
        lblintro.setText(LocalStorage.getInstance().getCopy("Rules_IntroText"));
        lblOutro.setText(LocalStorage.getInstance().getCopy("Rules_FooterText"));

        return view;
    }

}
